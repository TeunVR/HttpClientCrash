HttpClientCrash
===============

Some crashes in Xamarin/Mono HttpClient on iOS and Android

Multiple simulatenous postAsync-calls seem to cause issues on iOS and Android.

iOS start with 2 POSTs:

``2014-11-28 12:29:17.177 HttpClientTest2[21202:2929810] System.Net.ProtocolViolationException: The number of bytes to be written is greater than the specified ContentLength.
  at System.Net.WebConnectionStream.CheckWriteOverflow (Int64 contentLength, Int64 totalWritten, Int64 size) [0x0002d] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System/System.Net/WebConnectionStream.cs:577 
  at System.Net.WebConnectionStream.BeginWrite (System.Byte[] buffer, Int32 offset, Int32 size, System.AsyncCallback cb, System.Object state) [0x001a3] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System/System.Net/WebConnectionStream.cs:528 
  at System.Threading.Tasks.TaskFactory`1[System.Object].FromAsyncBeginEnd[Byte[],Int32,Int32] (System.Func`6 beginMethod, System.Func`2 endMethod, System.Byte[] arg1, Int32 arg2, Int32 arg3, System.Object state, TaskCreationOptions creationOptions) [0x00062] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Threading.Tasks/TaskFactory_T.cs:453 
  at System.Threading.Tasks.TaskFactory.FromAsync[Byte[],Int32,Int32] (System.Func`6 beginMethod, System.Action`1 endMethod, System.Byte[] arg1, Int32 arg2, Int32 arg3, System.Object state, TaskCreationOptions creationOptions) [0x00023] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Threading.Tasks/TaskFactory.cs:570 
  at System.Threading.Tasks.TaskFactory.FromAsync[Byte[],Int32,Int32] (System.Func`6 beginMethod, System.Action`1 endMethod, System.Byte[] arg1, Int32 arg2, Int32 arg3, System.Object state) [0x00000] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Threading.Tasks/TaskFactory.cs:561 
  at System.IO.Stream.WriteAsync (System.Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken) [0x00000] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.IO/Stream.cs:343 
  at System.IO.Stream.WriteAsync (System.Byte[] buffer, Int32 offset, Int32 count) [0x00000] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.IO/Stream.cs:338 
  at System.Net.Http.ByteArrayContent.SerializeToStreamAsync (System.IO.Stream stream, System.Net.TransportContext context) [0x00000] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System.Net.Http/System.Net.Http/ByteArrayContent.cs:68 
  at System.Net.Http.HttpContent.CopyToAsync (System.IO.Stream stream, System.Net.TransportContext context) [0x00029] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System.Net.Http/System.Net.Http/HttpContent.cs:97 
  at System.Net.Http.HttpContent.CopyToAsync (System.IO.Stream stream) [0x00000] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System.Net.Http/System.Net.Http/HttpContent.cs:86 
  at System.Net.Http.HttpClientHandler+<SendAsync>c__async0.MoveNext () [0x001bc] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System.Net.Http/System.Net.Http/HttpClientHandler.cs:331 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x0000b] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.ExceptionServices/ExceptionDispatchInfo.cs:62 
  at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1+ConfiguredTaskAwaiter[System.Net.Http.HttpResponseMessage].GetResult () [0x00034] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.CompilerServices/ConfiguredTaskAwaitable_T.cs:62 
  at System.Net.Http.HttpClient+<SendAsyncWorker>c__async0.MoveNext () [0x000a9] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System.Net.Http/System.Net.Http/HttpClient.cs:273 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x0000b] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.ExceptionServices/ExceptionDispatchInfo.cs:62 
  at System.Runtime.CompilerServices.TaskAwaiter`1[System.Net.Http.HttpResponseMessage].GetResult () [0x00034] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.CompilerServices/TaskAwaiter_T.cs:59 
  at PCL.MyClass+<PostAsync>c__async1.MoveNext () [0x000c3] in /Users/User/Documents/XamarinProjects/HttpClientTest2/PCL/MyClass.cs:74
``

iOS 20 POSTs:
2014-11-28 12:29:52.069 HttpClientTest2[21271:2933248] System.InvalidOperationException: Cannot re-call start of asynchronous method while a previous call is still in progress.
  at System.Net.HttpWebRequest.BeginGetResponse (System.AsyncCallback callback, System.Object state) [0x000a5] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System/System.Net/HttpWebRequest.cs:909 
  at System.Threading.Tasks.TaskFactory`1[System.Net.WebResponse].FromAsyncBeginEnd (System.Func`3 beginMethod, System.Func`2 endMethod, System.Object state, TaskCreationOptions creationOptions) [0x0005f] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Threading.Tasks/TaskFactory_T.cs:343 
  at System.Threading.Tasks.TaskFactory`1[System.Net.WebResponse].FromAsync (System.Func`3 beginMethod, System.Func`2 endMethod, System.Object state, TaskCreationOptions creationOptions) [0x00000] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Threading.Tasks/TaskFactory_T.cs:326 
  at System.Threading.Tasks.TaskFactory`1[System.Net.WebResponse].FromAsync (System.Func`3 beginMethod, System.Func`2 endMethod, System.Object state) [0x00000] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Threading.Tasks/TaskFactory_T.cs:320 
  at System.Net.WebRequest.GetResponseAsync () [0x00000] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System/System.Net/WebRequest.cs:527 
  at System.Net.Http.HttpClientHandler+<SendAsync>c__async0.MoveNext () [0x002e9] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System.Net.Http/System.Net.Http/HttpClientHandler.cs:342 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x0000b] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.ExceptionServices/ExceptionDispatchInfo.cs:62 
  at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1+ConfiguredTaskAwaiter[System.Net.Http.HttpResponseMessage].GetResult () [0x00034] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.CompilerServices/ConfiguredTaskAwaitable_T.cs:62 
  at System.Net.Http.HttpClient+<SendAsyncWorker>c__async0.MoveNext () [0x000a9] in ///Library/Frameworks/Xamarin.iOS.framework/Versions/8.4.0.43/src/mono/mcs/class/System.Net.Http/System.Net.Http/HttpClient.cs:273 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x0000b] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.ExceptionServices/ExceptionDispatchInfo.cs:62 
  at System.Runtime.CompilerServices.TaskAwaiter`1[System.Net.Http.HttpResponseMessage].GetResult () [0x00034] in /Developer/MonoTouch/Source/mono/mcs/class/corlib/System.Runtime.CompilerServices/TaskAwaiter_T.cs:59 
  at PCL.MyClass+<PostAsync>c__async1.MoveNext () [0x000c3] in /Users/User/Documents/XamarinProjects/HttpClientTest2/PCL/MyClass.cs:74 

Android start with two POSTS: 
System.Net.ProtocolViolationException: The number of bytes to be written is greater than the specified ContentLength.
  at System.Net.WebConnectionStream.CheckWriteOverflow (Int64 contentLength, Int64 totalWritten, Int64 size) [0x00000] in <filename unknown>:0 
  at System.Net.WebConnectionStream.BeginWrite (System.Byte[] buffer, Int32 offset, Int32 size, System.AsyncCallback cb, System.Object state) [0x00000] in <filename unknown>:0 
  at System.Threading.Tasks.TaskFactory`1[System.Object].FromAsyncBeginEnd[Byte[],Int32,Int32] (System.Func`6 beginMethod, System.Func`2 endMethod, System.Byte[] arg1, Int32 arg2, Int32 arg3, System.Object state, TaskCreationOptions creationOptions) [0x00000] in <filename unknown>:0 
  at System.Threading.Tasks.TaskFactory.FromAsync[Byte[],Int32,Int32] (System.Func`6 beginMethod, System.Action`1 endMethod, System.Byte[] arg1, Int32 arg2, Int32 arg3, System.Object state, TaskCreationOptions creationOptions) [0x00000] in <filename unknown>:0 
  at System.Threading.Tasks.TaskFactory.FromAsync[Byte[],Int32,Int32] (System.Func`6 beginMethod, System.Action`1 endMethod, System.Byte[] arg1, Int32 arg2, Int32 arg3, System.Object state) [0x00000] in <filename unknown>:0 
  at System.IO.Stream.WriteAsync (System.Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken) [0x00000] in <filename unknown>:0 
  at System.IO.Stream.WriteAsync (System.Byte[] buffer, Int32 offset, Int32 count) [0x00000] in <filename unknown>:0 
  at System.Net.Http.ByteArrayContent.SerializeToStreamAsync (System.IO.Stream stream, System.Net.TransportContext context) [0x00000] in <filename unknown>:0 
  at System.Net.Http.HttpContent.CopyToAsync (System.IO.Stream stream, System.Net.TransportContext context) [0x00000] in <filename unknown>:0 
  at System.Net.Http.HttpContent.CopyToAsync (System.IO.Stream stream) [0x00000] in <filename unknown>:0 
  at System.Net.Http.HttpClientHandler+<SendAsync>c__async0.MoveNext () [0x00000] in <filename unknown>:0 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x00000] in <filename unknown>:0 
  at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1+ConfiguredTaskAwaiter[System.Net.Http.HttpResponseMessage].GetResult () [0x00000] in <filename unknown>:0 
  at System.Net.Http.HttpClient+<SendAsyncWorker>c__async0.MoveNext () [0x00000] in <filename unknown>:0 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x00000] in <filename unknown>:0 
  at System.Runtime.CompilerServices.TaskAwaiter`1[System.Net.Http.HttpResponseMessage].GetResult () [0x00000] in <filename unknown>:0 

Android GET 20:
System.Threading.Tasks.TaskCanceledException: The Task was canceled
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x00000] in <filename unknown>:0 
  at System.Runtime.CompilerServices.TaskAwaiter`1[System.Net.Http.HttpResponseMessage].GetResult () [0x00000] in <filename unknown>:0 
  at System.Net.Http.HttpClientHandler+<SendAsync>c__async0.MoveNext () [0x00000] in <filename unknown>:0 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x00000] in <filename unknown>:0 
  at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1+ConfiguredTaskAwaiter[System.Net.Http.HttpResponseMessage].GetResult () [0x00000] in <filename unknown>:0 
  at System.Net.Http.HttpClient+<SendAsyncWorker>c__async0.MoveNext () [0x00000] in <filename unknown>:0 
--- End of stack trace from previous location where exception was thrown ---
  at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw () [0x00000] in <filename unknown>:0 
  at System.Runtime.CompilerServices.TaskAwaiter`1[System.Net.Http.HttpResponseMessage].GetResult () [0x00000] in <filename unknown>:0 

Android start with 20 POSTS:
System.InvalidOperationException: Cannot re-call start of asynchronous method while a previous call is still in progress.
  at System.Net.HttpWebRequest.BeginGetResponse (System.AsyncCallback callback, System.Object state) [0x00000] in <filename unknown>:0 
  at System.Threading.Tasks.TaskFactory`1[System.Net.WebResponse].FromAsyncBeginEnd (System.Func`3 beginMethod, System.Func`2 endMethod, System.Object state, TaskCreationOptions creationOptions) [0x00000] in <filename unknown>:0 
  at System.Threading.Tasks.TaskFactory`1[System.Net.WebResponse].FromAsync (System.Func`3 beginMethod, System.Func`2 endMethod, System.Object state, TaskCreationOptions creationOptions) [0x00000] in <filename unknown>:0 
  at System.Threading.Tasks.TaskFactory`1[System.Net.WebResponse].FromAsync (System.Func`3 beginMethod, System.Func`2 endMethod, System.Object state) [0x00000] in <filename unknown>:0 
  at System.Net.WebRequest.GetResponseAsync () [0x00000] in <filename unknown>:0 

