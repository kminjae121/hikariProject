using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class TestFolder : MonoBehaviour
{
    public void Test()
    {

        Process.Start("explorer.exe", "https://ggm.gondr.net/user/profile/303");

        Process ExternalProcess = new(); // procss를 실행시키는 인스턴스 생성
        ExternalProcess.StartInfo.FileName = @"C:\Users\김연호\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Steam";
        ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        ExternalProcess.Start();
        ProcessStartInfo startInfo = new(@"C:\Program Files (x86)\Steam\steam.exe");
        //startInfo.Arguments = "www.naver.com";
        startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        Process.Start(startInfo);


        //ExternalProcess.StartInfo.FileName = @"C:\Users\김연호\Pictures\멤버";
        //ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

        //ExternalProcess.Start();

        //윈도우종료
        //System.Diagnostics.Process.Start("cmd.exe", "ShutDown.exe -s -f -t 00");


        //재부팅
        //System.Diagnostics.Process.Start("cmd.exe", "ShutDown.exe -r -f -t 00");

        //도스명령어 실행
        //System.Diagnostics.Process.Start("cmd.exe", "/c dir");

        //Process myProcess = new Process();
        //string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //myProcess.StartInfo.FileName = myDocumentsPath + @"\MyFile.doc";
        //myProcess.StartInfo.Verb = "Print"; //읽을 수 없는 파일 실?행
        //myProcess.StartInfo.CreateNoWindow = true; //윈도우를 새로 만들것인가
        //myProcess.Start();
    }
    
}
