# About
A team project for the Microsoft Enterprise (PROG3050) course at Conestoga College. This is a virtual game store created in ASP.NET Core 2.2 using Model-View-Controller (MVC) and a code-first design. Created by Team TurboGames.

**Team:** TurboGames

**Members:** Lucas W, Cam L, Xander D, and Fernando G

**Using:** ASP.NET Core 2.2 MVC

## How to get started with git

*If you already have the project cloned then skip #1*

1. Open git bash in your current folder and paste: `git clone git@github.com:LucasWinkler/TurboGames-ConestogaVirtualGameStore.git`

You should now have the project in your current folder.

2. You can switch to different branches by typing `git checkout <branch-name>` e.g. `git checkout develop`

You will most likely want to start in the develop branch.

3. Pull the latest changes using `git pull` just incase you don't have them

When you need to work on the project you will add a new branch for that specific feature

4. To do so type: 
```
git checkout -b <feature-name> develop    <-- e.g. git checkout -b add-games develop (creates new branch based on the develop branch)
git push --set-upstream origin <feature-name>   <-- Pushes the new branch to the remote repository (github)
```

5. Every time you add a decent amount of code type (DO THIS A LOT!!!!):
```
git add .			<-- Adds all changed files
git commit -m "Commit message"		<--	e.g. git commit -m "Added wishlist page"
``` 

The next step should be done almost as often as you commit. 
This way your feature is always up-to-date with github.

6. To push/upload all of your commits to the remote feature branch type: `git push <feature-name>`

7. Once you have finished creating your feature type: 
```
git checkout develop
git merge --no-f <feature-name>
git branch -d <feature-name>
git push
```

This will (hopefully) switch to develop, merge your feature branch into develop, delete your feature branch and then push all changes to github.

Tips: 
`git status` will  return information on new changes.
Mess up when creating a branch and want to remake or rename it? `git checkout develop` then `git branch -D <feature-name>`

## How to work on the project

After reading the *"How to get started with git"** section you should know how to create your own feature branch and start commiting changes.

This section is going to be teaching you about how to actually work on the project.

**Example for creating a game table with a controller and crud views**

1. Create a class under Models named Game and provide it with properties that a table would have.

Example:
```
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
    }
```

2. Create a DbSet for this model in Data/ApplicationDbContext and override the table name so it's not plural (preference)

Example:
```
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Database Sets
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Rename new tables
            builder.Entity<Game>().ToTable("Game");
        }
    }
```

3. Add a migration for the new data. (Migrations create code from your models that will create the database when update-database is called)

In nuget console: `Add-Migration <migration-name>` e.g. `Add-Migration AddedGameModel` It almost acts as a commit message for data.

4. Update the database

In nuget console: `Update-Database`

You have now just created a data model and created a migration so that it can be added it to the database.
You're now able to start creating the controllers and views for this model.

5. Right click on Controllers -> Add Controllers -> MVC Controller with views, using Entity Framework

Model class: Select the model in this case it's Game
Data conetxt class: Select the database context which is ApplicationDbContext

Keep the rest default so that it auto-generates CRUD views that can be changd later and click Add

You just created a new table, a controller and crud views. You can now start working on the controller and views.