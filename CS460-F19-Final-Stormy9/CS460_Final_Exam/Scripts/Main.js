// to validate event start date is not set for in the past --
//   check constraint won't allow that -- but also returns error page   [=]
//
var today = new Date();
var dd = today.getDate();
var mm = today.getMonth() + 1; //January is 0!
var yyyy = today.getFullYear();

if (dd < 10) {
    dd = '0' + dd
}
if (mm < 10) {
    mm = '0' + mm
}

today = yyyy + '-' + mm + '-' + dd;

document.getElementById("eventStart").setAttribute("min", today);

es = document.getElementById("eventStart").val();

if (es < today) {
    document.getElementById("oops").innerHTML = "event can't start in past";
}

// okay, so this doesn't give an error message page (Good!) -->
// but neither does it reflect any user message on * this * page-- >
// it simply doesn't let you click on a date that's in the future! -- >
//=======================================================================================
//
// to validate duration is greater than 0     (i hope, ha!)
//
document.getElementById("eventDur").setAttribute("min", 0);