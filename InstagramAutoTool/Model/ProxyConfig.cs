using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using OpenQA.Selenium;

namespace InstagramAutoTool.Model
{
    public class ProxyConfig
    {
        private Proxy _proxy;

        public ProxyConfig()
        {
            try
            {
                _proxy = new Proxy();
                _proxy.Kind = ProxyKind.Manual;
                _proxy.IsAutoDetect = false;
                RotateIp("../../Assets/NetWork/ip.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ProxyConfig(string path)
        {
            try
            {
                _proxy = new Proxy();
                _proxy.Kind = ProxyKind.Manual;
                _proxy.IsAutoDetect = false;
                RotateIp(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public Proxy Proxy => _proxy;

        
        private List<string> ReadIpList(string path)
        {
            List<string> ipList = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        ipList.Add(line);
                    }
                }

                return ipList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public string RotateIp(string path)
        {
            try
            {
                List<string> ipList = ReadIpList(path);

                Random random = new Random();
                int testNum = 0;
                
                // while (true)
                // {
                    // testNum++;
                int ranNum = random.Next(ipList.Count);
                string ip = ipList[ranNum];
                            
                _proxy.HttpProxy =
                    _proxy.SslProxy = "38.154.227.167:5868";

                    // if (CanPing(ip))
                    //     return ip;
                    //
                    // if (testNum > 100)
                    //     throw new TimeoutException("Have no Proxy alive!");
                // }
                return ip;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        private static bool CanPing(string address)
        {
            Ping ping = new Ping();

            try
            {
                PingReply reply = ping.Send(address, 2000);
                if (reply == null) return false;

                return (reply.Status == IPStatus.Success);
            }
            catch (PingException e)
            {
                return false;
            }
        }
        
    }
}