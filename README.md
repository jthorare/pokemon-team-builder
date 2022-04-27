### Pokemon Team Builder

<p> I really like Pokemon. I decided that there were some websites like serebii.net and bulbapedia.bulbagarden.net that had features and information that I liked using,
  but lacked a key feature that I use everytime I play a pokemon game. A team builder so I can remember what I decided was going to be my team composition before I started
  my current playthrough. I wanted to combine the informational pages of the aforementioned sites with the Team Builder function being the key new piece.
  </p>
  
#### Tech Stack
1. ASP.NET Web API
2. Blazor Webassembly client using Blazorise and Radzen UI frameworks
3. MongoDB

<p>
  I decided to create my SPA using C# and use a relatively new technology, Webassembly applications. I created a Blazor Webassembly application with the intention of
  hosting on Netlify. I realized that my build time with proper Ahead-of-Time (AoT) compilation would cause my build time to be too long for the free Netlify hosting
  option.
  </p>
  
#### User Types

1. Anonymous user with access to all pages
2. Registered user with access to all pages and the ability to save teams to the database.
3. Contributor user with the ability to suggest improvements on the homepage to save to the database.
