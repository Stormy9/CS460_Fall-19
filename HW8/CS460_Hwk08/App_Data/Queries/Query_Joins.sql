SELECT AthleteName, Gender, CoachName, TeamName
	FROM Athletes as ath 
    	INNER JOIN Coaches as ch 
        	ON ath.CoachID = ch.CoachID
		INNER JOIN Teams as tm
			ON ath.TeamID = tm.TeamID
	ORDER BY AthleteName;