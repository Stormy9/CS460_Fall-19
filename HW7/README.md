CS460 - Homework 07!

Demo video for my MVC version of Homework 7 => https://youtu.be/6-4UXfweOWY

Okay..... 
So my main issue, was that i had totally blanked on how to properly link to or include or whatever, my `main.js` file.....
once I did that correctly *(thanks to a classmate suggesting I check that, from notes he had taken in class)*.....
my page comes up correctly from my MVC file, and also still functions correctly, and even looks as good as it did in my alternate version!
which, how good that is, depends upon personal taste, i guess.  Personally, i like the colors.     (=

<br>
Anyway, so my *other* main issue..... I still was blanking on how to work with the API calls via C# -- until a classmate sent me a recording of the screen of your in-class lecture on that -- which was just last night *(Sunday the 24th)*..... Now, after watching that, I feel like I could do it just fine -- everything 'clicked' again for me just like it had in class that day *(but I totally forgot by the time i got home and was able to start working on it)*.....

<br><br>
But I don't have the time to re-work everything, now, without getting behind before I even start on Homework 08.   :(
<br><br>
So my API calls are all still in AJAX.   :(

<br>
*(if that demo for Homework 7 had been a moodle video instead of just a one-time, in-class thing..... i wouldn't have ever been so lost in the first place!   (:  )*


<br><br>
___
Demo video for my 'alternate' version of Homework 7 => https://youtu.be/GjqSaDKVY88

As mentioned in the demo video -- and in the readme for the 'CS460_Hwk07_alt' folder on here, which i pushed those files here, too, in they're own sub-folder, just in case you're interested in seeing the code I did in jQuery/AJAX and how I handled the JSON and all that fun stuff..... 

I was really, really lost as to how to approach this in MVC, so far as structuring/arranging everything..... what to do with Models, if anything (*something*, right?) and how to go about handling the view from the HomeController, and building the view itself using Razor to access the things I needed to access..... doesn't that usually come from a Model?

But when I started working on this, I started first by practicing API calls with Postman and seeing what I got back -- how the JSON was structured..... some JSON responses were Objects (with nested objects) and some were an Array of Objects, and I had to know the structure in order to know how to get what I needed/wanted out of there.

Then I started working on re-acclimating myself to AJAX, and making Requests that way, and doing stuff with the JSON data returned.  (*first was saving the returned JSON data to it's own local variable*)

From there I kinda got carried away with remembering how to pull out the specific data pieces I was after, and saving each piece to local variables, and then doing stuff with them via jQuery to make them appear on an html page.  The funnest part was looping though the Array of Objects which held all the data for each repo..... except funner still was figuring out how to do the buttons to retrieve the appropriate list of commits for the repo you were asking to see a list of commits from.  That was something.  But an awesome something.

I was under the mis-impression that this would help me with this assignment, and that some of that would be transferrable -- at least the knowledge (re)gained (*i'd done stuff like this before, just not in a year or two*)..... but no, apparently it was not.   [=

I was (am) just so lost with how to even begin structuring all of this in a useful way in the MVC framework.   ]=

But I did make a site doing exactly everything that was asked for..... just with pure html/css/JavaScript-jQuery-AJAX.
