
select 	*
from people p
    inner join JOBDETAIL jd on p.people_id = jd.people_id
    inner join POST on jd.JOBTITLE = post.POST_ID
    inner join ORGLEVEL3 o3 on jd.orglevel3 = o3.orglevel3_id
    inner join ORGLEVEL2 o2 on o3.Orglevel2 = o2.orglevel2_id
    inner join region r on o2.region = r.region_id
where p.[status]='Active'
    and jd.principaljob='T'
    and jd.CURRENTRECORD='YES'
    and post.[Type] = 'Operational'




select * from PersonnelContractsReport

