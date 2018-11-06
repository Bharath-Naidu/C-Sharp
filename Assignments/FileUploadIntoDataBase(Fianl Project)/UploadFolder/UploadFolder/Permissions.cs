using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;


namespace UploadFolder

{
   public  class Permissions

    {
       public PermissionRepository Permission = new PermissionRepository();
        public void GetPermmssion(ClientContext context, Folder newFolder, string localrootfolder)
        {
           
            string user;
            DirectorySecurity dSecurity = Directory.GetAccessControl(localrootfolder);
           /*--------------------------------------------- gets the users and their permissions---------------------------------*/ 
            foreach (FileSystemAccessRule rule in dSecurity.GetAccessRules(true, true, typeof(NTAccount)))
            {
                string[] splitRole = rule.FileSystemRights.ToString().Split(',');
                user = rule.IdentityReference.Value.Split(Convert.ToChar(92)).Last().ToString();
                foreach (string s in splitRole)
                {
                    DataTable MappedRoles = Permission.GetMappingRole(s);           /*-------------gets the roletype equivalent of the permission*/
                    List<RoleType> MaproleList = new List<RoleType>();
                    foreach (DataRow row in MappedRoles.Rows)
                    {
                        foreach (RoleType value in Enum.GetValues(typeof(RoleType)))
                        {
                            /*-------------gets the roletype object of the permission*/
                            if (value.ToString() == row["RoleType"].ToString())
                            {
                                MaproleList.Add(value);
                            }
                        }
                    }
                    if (MaproleList.Count > 0)
                    {
                        /*----------------- Assigns permissions of the folders-------------------------*/
                        AssignPermission(context, user, newFolder, MaproleList);
                    }
                }
            }
        }

        public void AssignPermission(ClientContext ctx, string User, Folder newFolder, List<RoleType> Mappedrole)
        {
            try
            {
                //List Doclibraryname = ctx.Web.Lists.GetByTitle(destinationLigraryTitle);
                //ctx.ExecuteQuery();
                /*------------------- assigns roles basing on mapping----------------- */
                foreach (RoleType roleType in Mappedrole)
                {
                    if (User.Length > 0)
                    {
                        newFolder.ListItemAllFields.BreakRoleInheritance(false, true);
                        var roles = new RoleDefinitionBindingCollection(ctx);
                        roles.Add(ctx.Web.RoleDefinitions.GetByType(roleType));
                        Microsoft.SharePoint.Client.Principal user1 = ctx.Web.EnsureUser(User + "@" + Environment.UserDomainName.ToLower() + ".com");
                        newFolder.ListItemAllFields.RoleAssignments.Add(user1, roles);
                       
                        newFolder.Update();
                        ctx.ExecuteQuery();
                    }
                }
                ctx.ExecuteQuery();
            }
            catch (Exception ex)
            {
                DAL.Repository.ErrrorLog.ErrorlogWrite(ex);
            }

        }
        public  void GetFilePermmssion(int FileId,string FilePath)
        {
              string user;
             FileSecurity dSecurity = System.IO.File.GetAccessControl(FilePath);
           
             
              foreach (FileSystemAccessRule rule in dSecurity.GetAccessRules(true, true, typeof(NTAccount)))
            {
               
                string[] UsernameSplit = rule.IdentityReference.Value.Split('\\');
                string DomainName = UsernameSplit[0];
                if (DomainName == Environment.UserDomainName)
                {
                    string[] splitRights = rule.FileSystemRights.ToString().Split(',');
                    user = rule.IdentityReference.Value.Split(Convert.ToChar(92)).Last().ToString()+"@acuvate.com";
                    foreach (string right in splitRights)
                    {
                        Console.WriteLine(UsernameSplit[1] + ":" + right);
                        Permission.InsertFilePermissions(FileId, user, right.Trim());
                    }
                }
            }
        }
        public  void GetFolderPermmssion(int FolderId, string FolderPath)
        {
            
            string user;
            DirectorySecurity dSecurity = Directory.GetAccessControl(FolderPath);
           
          

            foreach (FileSystemAccessRule rule in dSecurity.GetAccessRules(true, true, typeof(NTAccount)))
            {
                
                string[] UsernameSplit = rule.IdentityReference.Value.Split('\\');
                string DomainName = UsernameSplit[0];
                if (DomainName == Environment.UserDomainName)
                {
                 string[] splitRights = rule.FileSystemRights.ToString().Split(',');
                    user = rule.IdentityReference.Value.Split(Convert.ToChar(92)).Last().ToString()+"@acuvate.com"; 
                    foreach (string right in splitRights)
                    {
                        
                        Permission.InsertFolderPermissions(FolderId, user, right.Trim());
                   }
                }
            }
        }
    }
}
