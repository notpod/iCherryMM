# Installer script for Notpod
!define PRODUCT_NAME "iCherry Music Manager"
!define PRODUCT_VERSION "1.0"

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "icherrymm-${PRODUCT_VERSION}-installer.exe"

InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
BrandingText "${PRODUCT_NAME}"

  !define MUI_ABORTWARNING
  !define MUI_ICON "Resources\ita-new.ico"
  !define MUI_UNICON "Resources\ita-new.ico"
  !define MUI_COMPONENTSPAGE_SMALLDESC


 !include "MUI2.nsh"
 !insertmacro MUI_PAGE_LICENSE "LICENSE.TXT"
 !insertmacro MUI_PAGE_LICENSE "Docs\INSTALL NOTES.TXT"
 !insertmacro MUI_PAGE_DIRECTORY
 !insertmacro MUI_PAGE_INSTFILES
 !insertmacro MUI_PAGE_FINISH
 
 Section "${PRODUCT_NAME}" SecMain

        SetOutPath "$INSTDIR"
        File "bin\Release\Notpod.exe"
        File "bin\Release\log4net.dll"
        File "bin\Release\logging.xml"
        File "bin\Release\Interop.iTunesLib.dll"
        File "LICENSE.TXT"
        createShortCut "$SMPROGRAMS\iCherry Music Manager\iCherry Music Manager.lnk" "$INSTDIR\Notpod.exe"
        createShortCut "$SMPROGRAMS\iCherry Music Manager\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
        
        # define uninstaller name
        writeUninstaller $INSTDIR\uninstaller.exe

 SectionEnd
 
 Section "Uninstall"

    # Always delete uninstaller first
    delete $INSTDIR\uninstaller.exe

    # now delete installed file
    delete $INSTDIR\Notpod.exe
    delete $INSTDIR\log4net.dll
    delete $INSTDIR\logging.xml
    delete $INSTDIR\Interop.iTunesLib.dll

 sectionEnd