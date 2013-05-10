UC OpenID Provider
=========

This is an example [OpenID](http://openid.net/) provider, which currently uses UCD CAS for backing authentication. Importantly, the backing authentication could be changed easily (for example, to Shibboleth) while keeping a consistent interface for consumers to authenticate against.

OpenID is very simple to use, and can be easily added to existing sites. There are libraries for working with OpenID in most programming languages as well as plugins for common CMS providers and even easy to use third-party providers.

Example OpenID Consumers
==========

I've created sample OpenID consumers using multiple frameworks and languages to demonstrate the global application of OpenID:

- [http://openidrelay-net.azurewebsites.net/](http://openidrelay-net.azurewebsites.net/): ASP.NET 4.0
- [http://openidrelay-nodejs.azurewebsites.net/](http://openidrelay-nodejs.azurewebsites.net/): Node.js

In each example, simply visit the site and attempt to log in or visit the Member's Only page.

1. You will be asked to provide the OpenID endpoint you wish to use; Defaults to **this provider** [http://ucopenid.azurewebsites.net/](http://ucopenid.azurewebsites.net/). Note you can also use the Google Provider shown, or any other provider from across the web. The 
application author has the power to decide what authentication sources should be used, and this also enables the scenario of allowing users to log in with whatever provider they are comfortable with (say, if some of your users might not have a UC login).
  	

1. Once you pick a provider, click **Login** and you will be taken to that site to authenticate (this is where you might get a CAS or Shibboleth prompt if you use the UC provider).

1. Now the provider will verify that you came from the calling application (i.e. one of the consumer apps above) _**AND**_ optionally ask you to release specific attributes that the calling application requested. _This is awesome_ and gives a lot of power to the user, and a lot of flexibility to the application developer. For example, the .NET consumer asks for a **friendly name** and **employeeId**, which it will be given if a user clicks "yes" (note: these are just examples of attributes I made up).

1. Clicking yes will redirect you back to your original application, except now you will have an OpenID token associated with your session, and the calling application will have additional attributes (like your name) if it wants to customize your experience.  This OpenID token will not change, so the application can use it as a userID and welcome you back the next time you visit.

1. Now that you have logged in, enter the Member's Only section to be part of the few, the proud, the authenticated!


Advantages
========

So what have we gained here? What are the advantages over direct CAS or Shibboleth authentication? There are quite a few advantages actually, and it also opens up some major areas of improvement down the road.


- **Attribute Release Policy**: An OpenID consuming application can request what attributes it wants from a logging in user, and the user can see these requests and be informed of what their application receive. These attributes can be configured _per application_ without modifying XML configuration files, and in fact can even be changed on the fly per-user.

- **Federated Authentication**: The application developer has the _option_ to decide what providers their user's can utilize. If they only choose to use the UC Provider (or similar), then direct authentication happens much as with CAS. However, we have now enabled the ability to let users login with _either_ their UC login _or_ Google login (and there are plenty of others as well), allowing flexibility for applications which can't be limited to 100% active students.

- **Proven Authentication w/ Good Company**: Let's face it, authentication systems come and go. In my shortish time on campus, we've gone through DistAuth, CAS, Shibboleth, Google Apps, Office365/Azure. OpenID has the potential to provide a unified face for backing authentication technologies, and OpenID is embraced by all of the major players like Google, Facebook, Yahoo, Wordpress, etc.

- **Foundation for the Future**: By integrating with [OAuth](http://oauth.net/), we can provide additional interconnection and collaborating among campus applications. OAuth "enables a third-party application to obtain limited access to an HTTP service," which could spark data sharing across campus and help break down our overly prevalent data silos. _An example_: Currently any webservice on campus grants access to its data to one application at a time through use of some shared token. This drastically limits the scope of data sharing because the consuming application is necessarily given access to everything it may need, and thus needs to be extensively vetted (which is a slow, time consuming, and scary process). With OAuth, the consuming application could instead authenticate _on behalf of_ another user and submit a request within that context. Think of when you let 3rd party Facebook application post on your wall or 'like' content for you. Or maybe you use your iPhone to look at Twitter through an app from the app store. In both of those cases, those applications are authenticating _on behalf of you_ and sending your update requests directly, meaning the application itself can't access the data of anyone unless they give permission directly. I think this has wide ranging potential across many UC services, and drastically improves the ability of webservice authors (the data holders) to provide access to their data safely and securely.