UPDATE Repairs
SET repairinfo_id = RepairsInfo.id
FROM RepairsInfo
WHERE Repairs.id = RepairsInfo.repair_id