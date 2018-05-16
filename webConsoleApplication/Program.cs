using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Compute.Fluent;

namespace webConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("select your OS ");
            String OS = Console.ReadLine();
            Console.WriteLine("select your VM name ");
            String vmname = Console.ReadLine();
            Console.WriteLine("select your resource group ");
            String rg = Console.ReadLine();
            Console.WriteLine("select your DNS name ");
            String dns = Console.ReadLine();
            Console.WriteLine("select your username ");
            String user = Console.ReadLine();
            Console.WriteLine("select your password ");
            String password = Console.ReadLine();

            /*
            //var authProperties = "C:\\Users\\" + Environment.UserName + "\\azure\\auth.properties";
            var authProperties = "C:\\Users\\" + Environment.UserName + "\\azure\\auth.properties";
            IAzure azure = Azure.Authenticate(authProperties).WithDefaultSubscription();
            var linuxVM = azure.VirtualMachines.Define("Linux")
                .WithRegion(Region.UKWest)
                .WithNewResourceGroup("test-vm-app")
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIPAddressDynamic()
                .WithNewPrimaryPublicIPAddress("mylinuxvmdns")
                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.CentOS7_2)
                .WithRootUsername("sam")
                .WithRootPassword("Password1!")
                .WithSize(VirtualMachineSizeTypes.StandardA1v2);

            Console.WriteLine("VM properties set");
            var machine = azure.VirtualMachines.Create(linuxVM);
            Console.WriteLine("VM created");*/
        }
    }
}
