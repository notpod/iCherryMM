# Installer script for Notpod
!define PRODUCT_NAME "ICherry Music Manager"
!define PRODUCT_VERSION "1.0"
!define MUI_ABORTWARNING
!define MUI_ICON ".\Resources\icherry-icon.ico"
!define MUI_UNICON ".\Resources\icherry-icon.ico"

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "icherrymm-${PRODUCT_VERSION}-installer.exe"

InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
BrandingText "${PRODUCT_NAME}"
	
!include "MUI2.nsh"

!define MUI_WELCOMEPAGE_TITLE_3LINES
!define MUI_WELCOMEPAGE_TITLE "${PRODUCT_NAME} ${PRODUCT_VERSION}"
!define MUI_WELCOMEPAGE_TEXT "Welcome to the installation program for ${PRODUCT_NAME} ${PRODUCT_VERSION}.$\r$\n$\r$\nThis program will install ${PRODUCT_NAME} ${PRODUCT_VERSION} onto your computer. Please make sure you save any open files before you continue. Please read the instructions and information carefully throughout this installation.$\r$\n$\r$\nThanks for choosing ${PRODUCT_NAME}! We hope you will enjoy the application."
!define MUI_WELCOMEFINISHPAGE_BITMAP "Resources\icherry-banner.bmp"
!insertmacro MUI_PAGE_WELCOME

!define MUI_PAGE_HEADER_TEXT "${PRODUCT_NAME} ${PRODUCT_VERSION} License"
!define MUI_PAGE_HEADER_SUBTEXT "Please read and accept the application license."
!insertmacro MUI_PAGE_LICENSE "LICENSE.TXT"

!define MUI_PAGE_HEADER_TEXT "${PRODUCT_NAME} ${PRODUCT_VERSION} installation information"
!define MUI_PAGE_HEADER_SUBTEXT "Make sure you read this carefully before continuing."
!insertmacro MUI_PAGE_LICENSE "Docs\INSTALL NOTES.TXT"

!define MUI_PAGE_HEADER_TEXT "Installation location"
!define MUI_PAGE_HEADER_SUBTEXT "Where do you want ${PRODUCT_NAME} installed?"
!insertmacro MUI_PAGE_DIRECTORY


!define MUI_TEXT_INSTALLING_TITLE "Now installing ${PRODUCT_NAME} ${PRODUCT_VERSION}..."
!insertmacro MUI_PAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"
 
 Section "${PRODUCT_NAME}" SecMain


        SetOutPath "$INSTDIR"
        File /oname=ICherryMusicManager.exe "bin\Release\Notpod.exe"
        File "bin\Release\log4net.dll"
        File "bin\Release\logging.xml"
        File "bin\Release\Interop.iTunesLib.dll"
        File "LICENSE.TXT"
        createShortCut "$SMPROGRAMS\ICherry Music Manager\ICherry Music Manager.lnk" "$INSTDIR\ICherryMusicManager.exe"
        createShortCut "$SMPROGRAMS\ICherry Music Manager\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
        
        # define uninstaller name
        writeUninstaller $INSTDIR\uninstaller.exe

 SectionEnd
 
 Section "Uninstall"

    # Always delete uninstaller first
    delete $INSTDIR\uninstaller.exe

    # now delete installed file
    delete $INSTDIR\ICherryMusicManager.exe
    delete $INSTDIR\log4net.dll
    delete $INSTDIR\logging.xml
    delete $INSTDIR\LICENSE.txt
	delete $INSTDIR\icherrymm.log
	delete $INSTDIR\Interop.iTunesLib.dll
	delete $INSTDIR

 SectionEnd
