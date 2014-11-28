HttpClientCrash
===============

Some crashes in Xamarin/Mono HttpClient on iOS and Android

Multiple simulatenous postAsync-calls seem to cause issues on iOS and Android.

Besides that it looks like Android is not executing the requests in parallel (should do 2 in parallel according to ServicePointManager.DefaultConnectionLimit. But it looks like it is only doing one request at a time.

To run the project start the nodejs server from the TestServer subdirectory first:
- npm init
- npm start

Also when testing on device set the IP-address of your nodejs-server in MyClass.cs

iOS start with 2 POSTs:
------
System.Net.ProtocolViolationException: The number of bytes to be written is greater than the specified ContentLength.

iOS 20 POSTs:
-------
2014-11-28 12:29:52.069 HttpClientTest2[21271:2933248] System.InvalidOperationException: Cannot re-call start of asynchronous method while a previous call is still in progress.

Android start with two POSTS: 
---------
System.Net.ProtocolViolationException: The number of bytes to be written is greater than the specified ContentLength.
  at System.Net.WebConnectionStream.CheckWriteOverflow (Int64 contentLength, Int64 totalWritten, Int64 size) [0x00000] in <filename unknown>:0 

Android GET 20:
---------
System.Threading.Tasks.TaskCanceledException: The Task was canceled

Android start with 20 POSTS:
-----------
System.InvalidOperationException: Cannot re-call start of asynchronous method while a previous call is still in progress.
  at System.Net.HttpWebRequest.BeginGetResponse (System.AsyncCallback callback, System.Object state) [0x00000] in <filename unknown>:0 
