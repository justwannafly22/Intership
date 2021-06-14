UPDATE Repairs
SET repairinfo_id = (SELECT id
					 FROM RepairsInfo t1
					 WHERE t1.repair_id=Repairs.id)