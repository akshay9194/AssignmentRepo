Swagger embedded for testing
Graph DS is use to cater problem.

Request Body
{
    "Projects":["P1", "P2", "P3", "P4"],
    "ProjectDependecies":
    [
        {
            "Name":"P1",
            "Dependencies":["P2","P3","P4"]
        },
        {
            "Name":"P2",
            "Dependencies":[]
        },
        {
            "Name":"P3",
            "Dependencies":["P4"]
        },
        {
            "Name":"P4",
            "Dependencies":[]
        }
    ]
}
