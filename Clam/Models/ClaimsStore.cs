using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clam.Models
{
    public class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            // Admin, Engineer, Developer
            new Claim("10100221", "Role View"),
            new Claim("10100222", "Role Create"), 
            new Claim("10100223", "Role Update"), 
            new Claim("10100224", "Role Remove"), 

            // Contributor, Student (1:View)
            new Claim("10100225", "Contributor View"), 
            new Claim("10100226", "Contributor Create"),
            new Claim("10100227", "Contributor Update"), 
            new Claim("10100228", "Contributor Remove"), 

            // Admin, Engineer, Developer
            new Claim("10100229", "Claim View"),
            new Claim("10100230", "Claim Add"),
            new Claim("10100231", "Claim Update"),
            new Claim("10100232", "Claim Remove"),

            // Admin, Engineer, Developer
            new Claim("10100233", "Account View"),
            new Claim("10100234", "Account Create"),
            new Claim("10100235", "Account Update"),
            new Claim("10100236", "Account Remove"),

            // Engineer, Developer
            new Claim("10100777", "All Access"),

            // Project Owner
            new Claim("10100314", "Project Manager"),

            // Discriminators
            new Claim("10100313", "Permission Create"),
            new Claim("10100314", "Permission Update"),
            new Claim("10100315", "Permission Remove"),
            new Claim("10100316", "Permission All"),
        };

        public static List<Claim> RoleClaims = new List<Claim>()
        {
            new Claim("2000106221", "Manage Roles"),
            new Claim("2000106222", "Manage Claims"),
            new Claim("2000106223", "Manage Accounts"),
            new Claim("2000106224", "Manage Contributions"),
            new Claim("2000106225", "Manage All")
        };

        enum PermissionClaimTypes
        {
            Level_One,
            Level_Two,
            Level_Three,
            Level_Four
        }

        enum PermissionClaimValues
        {
            View,
            Edit,
            Create,
            Delete,
            Manage
        }
    }
}
