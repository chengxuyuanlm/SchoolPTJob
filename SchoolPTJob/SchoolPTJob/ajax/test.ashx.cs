using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using Dal;
using Bll;
using System.IO;  
using System.IO.Compression;
using Microsoft.Win32;
using System.Diagnostics;  

namespace SchoolPTJob.ajax
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["file1"];
            //存入文件
            if (file.ContentLength > 0)
            {
                //file.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/image/") + System.IO.Path.GetFileName(file.FileName));
                //context.Response.Redirect("../page/test.html");
                //context.Response.Write(System.Web.HttpContext.Current.Server.MapPath("/image/") + System.IO.Path.GetFileName(file.FileName));

                string filename = System.IO.Path.GetFileName(file.FileName);
                string zipPath = System.Web.HttpContext.Current.Server.MapPath("/image/") + System.IO.Path.GetFileName(file.FileName);
                string extractPath = System.Web.HttpContext.Current.Server.MapPath("/image/") + System.IO.Path.GetFileName(file.FileName);
                file.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/image/") + System.IO.Path.GetFileName(file.FileName));
                DeCompressRar(zipPath, zipPath);

                   
            }
        }
        /// <summary>
        /// 将格式为rar的压缩文件解压到指定的目录
        /// </summary>
        /// <param name="rarFileName">要解压rar文件的路径</param>
        /// <param name="saveDir">解压后要保存到的目录</param>
        public static void DeCompressRar(string rarFileName, string saveDir)
        {
            string regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe";
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regKey);
            string winrarPath = registryKey.GetValue("").ToString();
            registryKey.Close();
            string winrarDir = System.IO.Path.GetDirectoryName(winrarPath);
            String commandOptions = string.Format("x {0} {1} -y", rarFileName, saveDir);

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = System.IO.Path.Combine(winrarDir, "rar.exe");
            processStartInfo.Arguments = commandOptions;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
        }
        /// <summary>   
        /// 功能：解压zip格式的文件。   
        /// </summary>   
        /// <param name="zipFilePath">压缩文件路径</param>   
        /// <param name="unZipDir">解压文件存放路径,为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹</param>   
        /// <returns>解压是否成功</returns>   
        public static void UnZipFile(string zipFilePath, string unZipDir)
        {

            if (zipFilePath == string.Empty)
            {
                throw new Exception("压缩文件不能为空！");
            }
            if (!File.Exists(zipFilePath))
            {
                throw new Exception("压缩文件不存在！");
            }
            //解压文件夹为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹                if (unZipDir == string.Empty)
            unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            if (!unZipDir.EndsWith("//"))
                unZipDir += "//";
            if (!Directory.Exists(unZipDir))
                Directory.CreateDirectory(unZipDir);

            //try
            //{
            //    using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
            //    {
            //        ZipEntry theEntry;
            //        while ((theEntry = s.GetNextEntry()) != null)
            //        {
            //            string directoryName = Path.GetDirectoryName(theEntry.Name);
            //            string fileName = Path.GetFileName(theEntry.Name);
            //            if (directoryName.Length > 0)
            //            {
            //                Directory.CreateDirectory(unZipDir + directoryName);
            //            }
            //            if (!directoryName.EndsWith("//"))
            //                directoryName += "//";
            //            if (fileName != String.Empty)
            //            {
            //                using (FileStream streamWriter = File.Create(unZipDir + theEntry.Name))
            //                {
            //                    int size = 2048;
            //                    byte[] data = new byte[2048];
            //                    while (true)
            //                    {
            //                        size = s.Read(data, 0, data.Length);
            //                        if (size > 0)
            //                        {
            //                            streamWriter.Write(data, 0, size);
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}