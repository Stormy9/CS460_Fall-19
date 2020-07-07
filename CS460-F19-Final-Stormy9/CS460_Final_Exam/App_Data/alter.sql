--ALTER TABLE Event
	--ADD CONSTRAINT EventStart CHECK (EventStart > GetDate());

	--ADD CONSTRAINT EventDuration CHECK (EventDuration > 0);

	-- why can you only add one contraint @time?  or how do you do multiple?

	--ADD EventTime TIME(0);

--ALTER TABLE RSVP
-- oops no -- there is already seeded data that would not satisfy constraint
-- if you added constraint for timestamp being "now"