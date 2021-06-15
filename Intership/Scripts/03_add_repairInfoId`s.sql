UPDATE
	TABLE_A
SET
	TABLE_A.repairinfo_id = TABLE_B.id
FROM
	Repairs AS TABLE_A
	INNER JOIN RepairsInfo AS TABLE_B
		ON TABLE_A.id = TABLE_B.repair_id
WHERE 
	TABLE_B.repair_id = TABLE_A.id