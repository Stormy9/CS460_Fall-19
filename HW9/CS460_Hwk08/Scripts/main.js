document.getElementById("stats_button").addEventListener("click", getGraph)
    // note how my function name is just plain, no '()' after it
    // 'stats_button' is the id of the button on the 'Stats.cshtml' page

// remember you have to precede your function name w/'function' keyword
function getGraph() {

    // so this doesn't work with val()..... oh wait -- now it is.   [=
    var AthID = $("#AthleteID").val();          // returning the drop-down values!
    var EvID = $("#EventID").val();                // and now it's not.   ]=
                                                // WHY?!?!!?  i didn't change anything!!!
                                                // oh, wait -- i did.  oops.
    var something;


    $.ajax({
        url: something,
        type: "GET",
        dataType: "json",

        //-------------------------------------------------------------------------------
        success: function (response) { 
            // do some stuff

        }, // end of SUCCESS function

        //-------------------------------------------------------------------------------
        error: function (xhr) {
            $("#athlete_event_graph").text("error getting graph..... " +
                xhr.status + " " + xhr.statusText);

            $("#test_jQ").text("AthleteID picked = " + AthID
                            + " and the EventID picked = " + EvID+ " from jQ)

        }, // end of ERROR function

    }) // end of ajax call / function

} // end of getGraph function