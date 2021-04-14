 
select total =count (*), fare = AVG(fare), distance = AVG(distance), duration = AVG(duration)
from TripsInfo
where DurationRange <> 'Just0' and [DistanceRange] <> 'Just0' and [FareRange] <> 'Just0'
 
  SELECT  [DurationRange], total =count (*)
  FROM TripsInfo
  where DurationRange <> 'Just0'
  GROUP BY [DurationRange]
  order by total desc
 
  SELECT  [FareRange], total =count (*)
  FROM TripsInfo
  where [FareRange] <> 'Just0'
  GROUP BY [FareRange]
  order by total desc
 
  SELECT  [DistanceRange], total =count (*)
  FROM TripsInfo
  where [DistanceRange] <> 'Just0'
  GROUP BY [DistanceRange]
  order by total desc
 
  SELECT  YEAR, total =count (*)
  FROM TripsInfo
  where [DurationRange] <> 'Just0' or [DistanceRange] <> 'Just0'
  GROUP BY YEAR
  order by total desc
 
  SELECT  MONTH, total =count (*)
  FROM TripsInfo
  where [DurationRange] <> 'Just0' or [DistanceRange] <> 'Just0'
  GROUP BY MONTH
  order by total desc
 
  SELECT  Hour, total =count (*)
  FROM TripsInfo
  where [DurationRange] <> 'Just0' or [DistanceRange] <> 'Just0'
  GROUP BY Hour
  order by total desc
 
  SELECT [PickUpBorough], [PickUpZone], total =count (*)
  FROM TripsInfo
  where [DurationRange] <> 'Just0' or [DistanceRange] <> 'Just0'
  GROUP BY  [PickUpBorough], [PickUpZone]
  order by total desc
 
  SELECT [DropOffBorough], [DropOffZone], total =count (*)
  FROM TripsInfo
  where [DurationRange] <> 'Just0' or [DistanceRange] <> 'Just0'
  GROUP BY [DropOffBorough], [DropOffZone]
  order by total desc
 