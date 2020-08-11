# Crowswood.SimpleConfig
Encapsulation of simple configuration.

Most projects need some form of configuration data. Often this can be implemented through the built in Properties, but not always.
This project supports either XML or JSON files to hold hierarchial data that can be defined in the project that uses the data.

The model classes that define the configuration data do not need any additional code in them to manage the transfer of the data from the config file to the model object.
This is all handled by the ConfigLoader object. Just create an instance of the ConfigLoader object with a type-param of the Interface that the config data implements.
Then call the Load method with a type-param of the class that is to be created, passing the path to the config file as the sole parameter.
