<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// from a in Athletes
// select a

// so this pulls up whole RaceResultsTable as expected
from rr in RaceResults
select rr.Athlete.AthleteName

// can't even select 2nd item -- says 'rr doesn't exist in that context'..... wtf??
 
 // can't add `.Distinct()` to end -- you get a 'NotSupportedException'
 //												Sequence operators not supported for type 'System.String'.

// now let's try this..... drill down in a bit.....
//from rr in RaceResults
//select rr.Athlete.AthleteName
// OMG, it worked!!!