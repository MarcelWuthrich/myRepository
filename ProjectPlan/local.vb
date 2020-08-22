
Public Module localProjectPlan

    'Public cnProjectPlan As String = "user id=ProjectPlan_read;Password=read_projectplan;data source=db.esb.local;persist security info=False;initial catalog=ProjectPlan"
    'Public cnProjectPlanWrite As String = "user id=ProjectPlan_write;Password=write_projectplan;data source=db.esb.local;persist security info=False;initial catalog=ProjectPlan"

    'Maison tablette
    'Public cnProjectPlanWUM As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    'Maison Fixe
    Public cnProjectPlanWUM As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    'ESB PROD
    Public cnProjectPlanProd As String = "user id=ProjectPlan;Password=write_projectplan;data source=SRV-ESB-020\ITTOOLS;persist security info=False;initial catalog=ProjectPlan"

    'ESB TEST
    Public cnProjectPlanTest As String = "user id=ProjectPlan;Password=write_projectplan;data source=SRV-ESB-020\ITTOOLS;persist security info=False;initial catalog=ProjectPlanTest"


End Module
