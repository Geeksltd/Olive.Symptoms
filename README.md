# Olive.Symptoms

It's a distributed enterprise Warning / KPI solution, enabling microservice-based applications to work as *agents* to produce non-compliance warning data, with a central repository to receive, process and communicate those warnings.

## Why we need warnings
Every business has rules and guidelines which cannot be implemented as simple application data validation rules (i.e. hard validation).
But they can be implemented as soft validations / warnings. Common reasons include:

- The rule is very complex with possible forgivable exceptions, while a hard-validation would be obstructive.
- The rule is experimental and needs time to mature
- The rule works on the combination of several data points that can come in any order.
- ...

## How does it work?

It consists of two main components: 

- A central component that collects, processes, measures and communicates the warning information.
- Microservice agent components, that send sympton data to the central component.

Each symptom item will have a UniqueID, Warning, Receipient and optionally a FixUrl.

## Installing the central component

Host **Central** as a microservice. Inside appSettings.json, register all current agents.

```json
   "Olive.Symptoms": {
       "Agents": [
         { "My Site 1": "https://mysite1.com/api/discover-symptoms" },
         { "My Site 2": "https://mysite2.com/api/discover-symptoms" },
         ...
       ]
   }
```

## Installing Agents

In each microservice, add the following:

### Step 1
Add the [Olive.Symptoms](https://www.nuget.org/packages/Olive.Symptoms/) nuget package.

### Step 2
Add the following class to the Website project:

```c#
public class SymptomsSource : Olive.Symptoms.Source
{
     public override async Task Discover()
     {                     
         foreach (var something in await SomeThings...())
         {
             if (Formula(something))
                 Add(new Symptom { UniqueID=..., Warning=..., Receipient=..., FixUrl=... });
         }        
     }
}
```

### Step 3 (.NET Core Apps)


2. In StartUp.cs, add: 
```c#
public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    base.Configure(app, env);
    ...
    app.UseSymptoms<SymptomsSource>();
    ...
}
```


### Step 3 (.Net 4.6+ Apps)
For legacy ASP.NET applications, add the following code to Web.config:

```xml
<configuration>
   <system.webServer>
      <handlers>
         <add name="Olive Symptoms" verb="GET" path="discover-symptoms.axd" type="SymptomsSource" />
      </handlers>
   <system.webServer>
</configuration>
```
