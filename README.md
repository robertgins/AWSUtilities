# AWS tools and utilities 

This project includes some commonly used AWS tools and utilities. Including the following:

## AutoScaleLifeCycleMonitor
This is a class that monitors the local instance, if it is part of an autoscaling group it can terminate itself 
when it detects that there is no mroe mwork to do. This simplifies the implementation of autoscaling groups by only having to define a
scale up/out rule instead of having to guess at scale down/in rules. You programatically set the monitor to be active by calling AddRef,
when your task is done you call Release. It also detects if the ASG it is participating in has a LifeCycleWait rule, in that mode it will
set and clear the Terminating:Wait flags during its last job.

## SqsQueueDispatcher
This class is a generic SQS monitor. It dequeues items from a named queue and calls a provided hanadler. It simplifies the process of 
polling for items, extending thier life, deleting items. It supports multiple worker threads. It also includes utilities for enqueuing
messages. It is integrated into the AutoScaleLifeCycleMonitor such that you can define a scale out group, and the host system will be
automatically terminated/scalled in when the queue is quiet for a defined period of time.  

## MySqlAuthentication
This are a collection of classes that provide for IAM role based authentication to MySql and Aurora RDS instances. This allows you to assgn
database access permissions based on IAM roles or IAM users instead of individual username/password combinations. The resulting connection string
no longer needs to contain a password. It is a bit tricky to configure (see notes in the class) but once running forces a very secure envionrment

## EntityFramework
This is a collection of classes supporting EntityFramework 2.X (3.1 coming soon) that specifically target Aurora RDS. This includes a
cloud Execution Strategy for Aurora, a MySql/Aurora index attribute, a full text attribute (for enabling FULLTEXT), an UpperCase attribute for
forcing strings to upper case. There are corresponding query extensions (for FULLTEXT) and model builder extensions (for intalling attributes)
as well as a DbContext base class that handles the implementation if you dont want to do it yourself.

## RedisElastiCache
This is a "cluster" capable implementation of the StackExchange IDatabase interface. The StackExchange implementation of the Redis connection
is quite capapble of recovering from ElastiCache cluster reconfigurations. However individual calls are not as resilient. This
class wrapps the underlying StackExchange client with a simple retry handler. A default retry handler is provided tgat deals with timeouts, you can 
provide your own retry handler by implementing a custom RedisRetryPolicy. 

## ConsoleCore.Demos
This is a console application with examples of each of the techniques. In order to demonstrate the EF attributes you need access to a MySQL
or Aurora server in MySQL mode. Update the connectionstring in the appsettings.json file to point to that server. If you want to test the IAM
authentication to RDS then you need to be running on an EC2 instance with IAM permissions (https://aws.amazon.com/premiumsupport/knowledge-center/users-connect-rds-iam/)
in this case yuou still need to include the username in the connection string but a password is not needed. Set the appsettings.json file
IAMRole and ConnectionString accordingly. The SQSDemo class reaads configuration for the queue name (DemoQueue), submits 2 jobs to it, 
and then processes them. If the SQSDemo is running on an EC2 instance participating in an ASG, then it will terminate itself when its
timeout expires. 

## AWS
If you are running on EC2 and have assigned permissions to an IAM role for that instance, everything should work as is. If however, you are running outside of AWS
or not on an EC2 instance (or workspace) with specific IAM permissions you will need to specify your AWS Access Key and Secret Key in such
a way that .NET Core 2.X will recognize it. The AWS guidance for that can be found here https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/deployment-ecs-specify-credentials.html . 
If you prefer a simpler method for testing, I suggest the use of enviornment variables which is internally supported. Use AWS_ACCESS_KEY_ID and AWS_SECRET_ACCESS_KEY for keys. Use AWS_REGION for your region. 
You can set those on your project Properties using the Environment Variables section of Debug tab.






