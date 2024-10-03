# Step Into Help

Empowering you to make the first step in helping those in need.

## What is Step Into Help?

Step Into Help is a concept that came about from a conversation with [Homefull](https://www.homefull.org/). I did a volunteer opportunity with them and was struck by the need and the good that can come from a small action. We made care packages from donations from work, and the combination of building care packages and hearing the stories of how these make a difference was powerful to me.

### So whats the problem?

Have you ever been at a red light and seen someone who is begging for money or food? Maybe they are just missing some new clothes or clearly in need of professional help?
What do you do in this situation?
I'll tell you what I do... one of two things.

1. I look for something to give them. Sometimes it's cash, sometimes it's a sandwich, and sometimes it's a ride to the nearest shelter.
2. I realize I can't help or the things I can offer aren't really going to help them.

In instance one I've put myself in some risky and awkward situations. Life is complicated and we don't always have the skills to help everyone. So therefore, I ditch option 1 unless its giving a resource that isn't cash.

In instance two I almost always am down to giving them cash. Now I know, it doesn't seem bad to give them money, however not knowing how that money gets leveraged has made me make some bad decisions in the past. I've given money to folks that I saw overdose on the side of the road and it has opened my eyes to the fact that I don't know where that money goes or what it's used for. So I don't want to contribute to that problem. Which leads to driving away and feeling like I could have done more.

If you're trained in your local area, you might call an organization such as Homefull to help. They have care packages, places to stay, access to social services and more. I advise you all to be aware of those folks and how you can get them in touch with this person or people you have stumbled upon.

### Cool we got it... now what is the app?

If you happen to be like most of us and don't know your local shelters and organization who offer help, you drive on by with a heavy heart. My goal in making this application is to remove that need of knowledge for those on the go or in a new area. So instead of you hopping onto your favorite search engine to find help, you can open this app and tell a handful of vendors and organizations to deploy services to this person in need. I also want you to know that your shared contribution in this makes a difference, so if the organization that takes your call to action is willing, they share a report back to you on what happened with their response. Maybe offer a picture or a story of the impact you made.

## Bottom Line

We all have the desire to help the folks who need it. Driving away knowing you could do more can be upsetting. Having this app can not only help you feel good about helping, but also help you know that your help is making a difference. A little act of telling an application, who knows the local organizations, who can deploy services to those in need, can make a big impact.

It all starts with you. Stepping up and offering to help. So please, share this app with your friends and family. Developers, if you're looking to contribute, please reach out to me. I'd love to talk about this app and how we can make it better.

## Developer Story

I had this volunteer opportunity with Homefull and I also had a backlog of technology I've wanted to refamiliarize or learn from scratch. It's hard for me to learn something new without applying it to a real world problem/ use case. So here we are. The stack I chose is a more stable one with .Net and SQLServer. I plan to make that my new piece of tech, despite building with it in the past (5 years ago). I'm sticking with React on the frontend because its something I know way too much about and its still the standard from my vantage point. Yes its simple enough to do a Next.js app, yes I could use other easier and simpler backend frameworks, but in order for me to get the full spectrum of tech, I need to do more than just Go and Node.js. Lets get after it, I'm excited to see where this goes.

## Folder Structure

- Controllers/: Contains API controllers that define endpoints and handle HTTP requests.
- Models/: Holds domain models or entities that represent the core business objects.
- Data/: Includes database context and any data access related classes.
- Services/: Contains business logic and operations that controllers can use.
  Repositories/: Implements the repository pattern for data access (if used).
- DTOs/ (Data Transfer Objects): Defines objects used for data transfer between layers, often used to shape API responses.
- Configurations/: Holds configuration classes, such as AutoMapper profiles.
- Middleware/: Custom middleware components, like error handling or request/response modification.
- Extensions/: Extension methods, often used for service configuration in Program.cs.
- Utilities/: Helper classes and utility functions.

[Task Board](https://www.notion.so/Step-Into-Help-1142a239c46c8040897cd46a22e24681)

## Running the app

1. Clone the repository
2. Run `docker compose up --build sqlserver -d`
3. Apply migrations `docker-compose exec web dotnet ef database update`
