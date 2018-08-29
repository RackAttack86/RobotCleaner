# RobotCleaner

When running the program it will execute the commands from the resources file ExampleInputs.

There is a test which would visit the most unique possible spaces given the parameters. However, I kept running into an OutOfMemory exception when attempting it. Depending on the box you are going to run this on that may not be an issue. If it was an issue for a final product I would have to investiage ways to conserve space such as an off site cache (i.e. Amazon redis cache) or a database.
