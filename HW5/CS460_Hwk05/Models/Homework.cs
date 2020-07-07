using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


// this is our model class
namespace CS460_Hwk05.Models
{
    public class Homework
    {
        [Key]
        public int ID { get; set; }

        //===============================================================================
        [Required, DisplayName("Priority")]
        [StringLength(18)]
        public string Priority { get; set; }

        //===============================================================================
        [Required, DisplayName("Due Date")]

        // found by Max on StackOverflow & posted to Slack 
        //              + i googled further for more examples etc.
        // adding this to the data definition gives me a date-picker in the view
        [DataType(DataType.Date)]           // need to find out more about syntax here
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:yyyy-MM-dd}")]
        // it also formats things correctly for going into our db..... yay!
        public DateTime DueDate { get; set; }

        //------------------------------------------------------------
        [Required, DisplayName("Due Time")]

        // modified from above  + stuff found googling (mostly StackOverflow)
        // adding this to data definition gives you a time-picker in the view
        [DataType(DataType.Time)]             // need to find out more about syntax here
        //[DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:hh:mm tt}")]
            // it did not like my format string -- see screenshot.....
                // commenting out this line ^^^ makes it all work again.....
                // BUT, it converts my 12-hour AM/PM time to military time.....
                // which is okay for now (i'll work on that over X-mas break.....)
        public TimeSpan DueTime { get; set; }

        //===============================================================================
        [Required, DisplayName("Dept.")]
        [StringLength(4)]
        public string Dept { get; set; }

        //===============================================================================
        [Required, DisplayName("Course #")]
        [StringLength(9)]
        public string Course { get; set; }

        //===============================================================================
        [Required, DisplayName("Assignment")]
        [StringLength(64)]
        public string Assignment { get; set; }

        //===============================================================================
        [Required, DisplayName("Notes:")]
        public string Notes { get; set; }

        //===============================================================================
    }
}
//=======================================================================================
// can do the annotations in different ways, like:
//     [Required, DisplayName("Priority")]
//  or
//      [Required]
//      [DisplayName("Due Date")]
//
// can the StringLength attribute be added in there?
// not sure if I like that idea, or seeing them each separate, better..
//
// note order does not matter:
//  [DisplayName("Due Time"), Required]     <== also is fine
//
//---------------------------------------------------------------------------------------
// i really just wanna understand how the whole date and time things work -- 
// becuase I want *actual* dates and times -- in order to do math with them later --
// i.e., how much time, in days/hours/minutes, you have left to complete a homework.....
//
//---------------------------------------------------------------------------------------
// Dr. Morse, in answering my inquiry:
// me:  "So is that what the Data Annotations are for -- to ensure the data is formatted
//       correctly for going into the db?
//
// said:  "..... Yes on the data annotations."      and
// 
// me:  "so, whether you use a date picker or just text input -- 
//       the data annotations do that role?"
//
// him:  "Correct.  Data annotations trigger both server side and 
//        client side validations (provided you use them in the view)
//
// me:  "wait -- can you give an example of using them in the view?
//       or is there an example on the class repo? 
//       in the user project stuff?"
//
// him:  "Yes.  It's the ValidationSummary and ValidationFor in: "
//        (added link for Create.cshtml in class repo for User_withDB2  
//              (../Views/Users/Create.cshtml )
//
//---------------------------------------------------------------------------------------
// it hadn't been covered in class..... but Dr. Morse said (in re: Max) that using
// Data Annotations for the Data Types is best practice -- which does make sense --
// and i need to learn a bit more about that
//      (okay so maybe i just don't remember it being covered in class.....)
//=======================================================================================
