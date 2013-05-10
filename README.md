UCD OpenID Provider
=========

This is an example [OpenID](http://openid.net/) provider, which currently uses UCD CAS for backing authentication. Importantly, the backing authentication could be changed easily (for example, to Shibboleth) while keeping a consistent interface for consumers to authenticate against.

OpenID is very simple to use, and can be easily added to existing sites. There are libraries for working with OpenID in most programming languages as well as plugins for common CMS providers and even easy to use third-party providers.

Example OpenID Consumers
==========

I've created sample OpenID consumers using multiple frameworks and languages to demonstrate the global application of OpenID:

- [http://openidrelay-net.azurewebsites.net/](http://openidrelay-net.azurewebsites.net/): ASP.NET 4.0
- [http://openidrelay-nodejs.azurewebsites.net/](http://openidrelay-nodejs.azurewebsites.net/): Node.js

In each example, simply visit the site and attempt to log in or visit the Member's Only page.

1. You will be asked to provide the OpenID endpoint you wish to use

1. asdasdas