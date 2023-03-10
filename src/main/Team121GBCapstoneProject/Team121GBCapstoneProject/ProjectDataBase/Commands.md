### Create Model classes and the DBContext subclass
```
dotnet ef dbcontext scaffold Name=GPConnection Microsoft.EntityFrameworkCore.SqlServer --context GPDbContext --context-dir Models --output-dir Models --verbose --force  --data-annotations
```

