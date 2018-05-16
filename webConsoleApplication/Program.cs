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
            String defaultOS = "KnownLinuxVirtualMachineImage.CentOS7_2";
            String defaultName = "default";
            String defaultRG = "test-vm-app";
            String defaultDNS = "mylinuxvmdns";
            String defaultUser = "user";
            String defaultPass = "Password1!";

            Console.WriteLine("Create your VM. Leave blank for default option ");
            Console.WriteLine("select your OS ");
            String OS = Console.ReadLine();
            if (OS.Equals("")) OS = defaultOS;
            Console.WriteLine("select your VM name ");
            String vmname = Console.ReadLine();
            if (vmname.Equals("")) vmname = defaultName;
            Console.WriteLine("select your resource group ");
            String rg = Console.ReadLine();
            if (rg.Equals("")) rg = defaultRG;
            Console.WriteLine("select your DNS name ");
            String dns = Console.ReadLine();
            if (dns.Equals("")) dns = defaultDNS;
            Console.WriteLine("select your username ");
            String user = Console.ReadLine();
            if (user.Equals("")) user = defaultUser;
            Console.WriteLine("select your password ");
            String password = Console.ReadLine();
            if (password.Equals("")) password = defaultPass; 

            try
            {
                var authProperties = "C:\\Users\\" + Environment.UserName + "\\azure\\auth.properties";
                IAzure azure = Azure.Authenticate(authProperties).WithDefaultSubscription();
                var linuxVM = azure.VirtualMachines.Define(vmname)
                    .WithRegion(Region.UKWest)
                    .WithNewResourceGroup(rg)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithNewPrimaryPublicIPAddress(dns)
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.CentOS7_2)
                    .WithRootUsername(user)
                    .WithRootPassword(password)
                    .WithSize(VirtualMachineSizeTypes.StandardA1v2);

                Console.WriteLine("VM properties set");
                var machine = azure.VirtualMachines.Create(linuxVM);
                Console.WriteLine("VM created");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }




            /*
            try
            {
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
                Console.WriteLine("VM created");
            }
            catch (Exception exc) {
                Console.WriteLine(exc.Message);
            }*/
        }
    }
}
