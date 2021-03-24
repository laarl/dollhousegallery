using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenLinkEmi()
	{
#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/emucat8/");
#endif
    }

    public void OpenLinkCarrie()
    {
#if !UNITY_EDITOR
		openWindow("https://freyaviol.tumblr.com/");
#endif
    }

    public void OpenLinkTAK()
    {
#if !UNITY_EDITOR
		openWindow("http://www.TAKensemble.com/");
#endif
    }

    public void OpenLinkAlexVG()
    {
#if !UNITY_EDITOR
		openWindow("https://www.alexvangils.com/");
#endif
    }

    public void OpenLinkBenVDH()
    {
#if !UNITY_EDITOR
		openWindow("https://www.bvandenheuvel.com/");
#endif
    }

    public void OpenLinkEvan()
    {
#if !UNITY_EDITOR
		openWindow("https://soundcloud.com/railing-at-the-moon");
#endif
    }

    public void OpenLinkDylan()
    {
#if !UNITY_EDITOR
		openWindow("https://www.dylandelgiudicemusic.com/");
#endif
    }

    public void OpenLinkNatalie()
    {
#if !UNITY_EDITOR
		openWindow("https://natalie.computer/");
#endif
    }

    public void OpenLinkJess()
    {
#if !UNITY_EDITOR
		openWindow("https://soundcloud.com/batstn");
#endif
    }

    public void OpenLinkSonia()
    {
#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/sonimonster/");
#endif
    }

    public void OpenLinkMeesh()
    {
#if !UNITY_EDITOR
		openWindow("mailto:msf2167@columbia.edu");
#endif
    }

    public void OpenLinkAmanda()
    {
#if !UNITY_EDITOR
		openWindow("https://www.amandaba.com/");
#endif
    }

    public void OpenLinkLucy()
    {
#if !UNITY_EDITOR
		openWindow("https://lucy-yao.com/");
#endif
    }

    public void OpenLinkMarina()
    {
#if !UNITY_EDITOR
		openWindow("http://www.marinakifferstein.com/");
#endif
    }

    public void OpenLinkForrest()
    {
#if !UNITY_EDITOR
		openWindow("https://soundcloud.com/forrest-eimold");
#endif
    }

    public void OpenLinkEddie()
    {
#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/sadpansy/");
#endif
    }

    public void OpenLinkAndrew()
    {
#if !UNITY_EDITOR
		openWindow("https://andrewyoon.art/");
#endif
    }

    public void OpenLinkIsabela()
    {
#if !UNITY_EDITOR
		openWindow("https://soundcloud.com/isabelatanashian");
#endif
    }

    public void OpenLinkAmber()
    {
#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/amberkela/");
#endif
    }

    public void OpenLinkZach()
    {
#if !UNITY_EDITOR
		openWindow("https://www.zacharyjamesritter.com/");
#endif
    }

    public void OpenLinkMolly()
    {
#if !UNITY_EDITOR
		openWindow("http://mollyxiuturner.com/");
#endif
    }

    public void OpenLinkIndira()
    {
#if !UNITY_EDITOR
		openWindow("https://www.indirawrs.com/");
#endif
    }

    public void OpenLinkRaquel()
    {
#if !UNITY_EDITOR
		openWindow("https://www.raquelacevedoklein.com/");
#endif
    }
    public void OpenLinkJacqueline()
    {
#if !UNITY_EDITOR
		openWindow("https://www.jacquelinebrockel.com/");
#endif
    }

    public void OpenLinkBrian()
    {
#if !UNITY_EDITOR
		openWindow("http://brianellissound.com/");
#endif
    }

    public void OpenLinkNina()
    {
#if !UNITY_EDITOR
		openWindow("http://ninafukuoka.com/");
#endif
    }

    public void OpenLinkInga()
    {
#if !UNITY_EDITOR
		openWindow("https://inga-manticas.squarespace.com");
#endif
    }

    public void OpenLinkDiana()
    {
#if !UNITY_EDITOR
		openWindow("https://www.dmr.land/");
#endif
    }

    public void OpenLinkReed()
    {
#if !UNITY_EDITOR
		openWindow("https://reedpuleo.com/");
#endif
    }

    public void OpenLinkLauren()
    {
#if !UNITY_EDITOR
		openWindow("https://soundcloud.com/laurensiess");
#endif
    }

    public void OpenLinkPablo()
    {
#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/pablomoconnell/");
#endif
    }

    public void OpenLinkSupport()
    {
#if !UNITY_EDITOR
		openWindow("https://igg.me/at/dollhousevr/x/25522826#/");
#endif
    }

    [DllImport("__Internal")]
	private static extern void openWindow(string url);

}