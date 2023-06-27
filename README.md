# WpfCaliburnMicroDemo
install/folders/centerSreen/comboBox/disable btn/multipleForms/contentControl

If the "Bootstrapper" class is defined in a different project or assembly, make sure you have added the necessary references to your current project.

APP CONFIGURATION
  1. install CaliburnMicro
  2. delete MainXaml file
  3. App.xaml - delete line MainXaml, then add the following code to start up:
     <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary>
                    <local:Bootstrapper x:Key="Bootstrapper" />
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
        
  4. add Bootstrapper class - and code (error: need to using ViewModels folder)
  5. add 3 folders
