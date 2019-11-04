# About

A team project for the PROG3050 Microsoft Enterprise course at Conestoga College. 
This project is a virtual game store created in ASP.NET Core 2.2.
It uses Razor Pages, MS SQL Server and a code-first design.

<table>
  <thead>
    <tr>
      <th>Role</th>
      <th>Name</th>
      <th>GitHub</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Project Manager</td>
      <td>Cameron Low</td>
      <td>https://github.com/Clow8128</td>
    </tr>
    <tr>
      <td>Backend Developer</td>
      <td>Lucas Winkler</td>
      <td>https://github.com/LucasWinkler</td>
    </tr>
    <tr>
      <td>Database Developer</td>
      <td>Xander Drinnan</td>
      <td>https://github.com/xanderdrinnan</td>
    </tr>
	 <tr>
      <td>Frontend Developer</td>
      <td>Fernando Guardado</td>
      <td>https://github.com/FernandoGuardado1998</td>
    </tr>
  </tbody>
</table>

## Branch Legend

<table>
  <thead>
    <tr>
      <th>Instance</th>
      <th>Branch</th>
      <th>Descriptions</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Production</td>
      <td>master</td>
      <td>Accepts merges from the development branch. We will merge to this branch at the end of each iteration.</td>
    </tr>
    <tr>
      <td>Development</td>
      <td>develop</td>
      <td>Accepts merges from feature branches. This is the branch with the latest features.</td>
    </tr>
    <tr>
      <td>Features</td>
      <td>feature-*</td>
      <td>Work on your assigned task in a feature branch. Always branched off from develop.</td>
    </tr>
  </tbody>
</table>

## Main Branches

Our repository has two main branches:

* `develop`
* `master`

The main branch that you will be working off of is `develop`. You don't work directly with it. You branch off of it with a feature branch.

The `master` branch is for production. This branch is never to be touched. It will be merged with `develop` at the end of iterations and that is what we will present. 

To start please clone the repo by using:

Standard: `git clone https://github.com/LucasWinkler/TurboGames-ConestogaVirtualGameStore.git`

*or*

SSH: `git clone git@github.com:LucasWinkler/TurboGames-ConestogaVirtualGameStore.git`

### Feature Branches

Feature branches are used when developing a new feature. It will always be merged back into the `develop` branch.

An example of `<feature-name>` could be `FriendsPage` so `feature-FriendsPage` or it could be the use case id.

* Must branch from: `develop`
* Must merge back into: `develop`
* Branch naming convention: `feature-<feature-name>`

#### Working with a feature branch

If the feature branch does not exist yet, create the branch locally and then push to GitHub. 

```
git checkout -b feature-<feature-name> develop         // creates a local branch for the new feature
git push --set-upstream origin feature-<feature-name>                
```

Constantly commit your changes to your branch. This way you can always keep track of your feature and you can always look back at previous commits.

```
git add .                                         // Add all new/changed files
git commit -m "Enter commit message here"         // e.g. Added friends page, fixed this, added that etc...
```

You should always push these commits to the remote repository (GitHub) so that anyone can see your latest changes.

```
git push
```

If any changes have been made to `develop` (you should be told when this happens) after you have created your branch then you must merge `develop` back into your feature branch.
This will get the latest changes and merge them wih your feature so that everyone is up-to-date. It also helps with merge conflicts later on.

```
git checkout develop 
git pull 
git checkout feature-<feature-name>
git merge develop                      // merges changes from develop into your feature branch
```

When a feature is complete let Lucas know and he will merge your feature into `develop` and then delete the feature branch.

```
git checkout develop                        // change to the develop branch  
git merge --no-ff feature-<feature-name>    // the --no-ff makes sure to create a commit during merge
git push origin develop                     // push merge changes
git push origin :feature-<feature-name>     // deletes the remote branch
git branch -d feature-<feature-name>        // (optional) deletes the branch locally	
```

## Razor Pages

Razor Pages is similar to MVC it just looks a little different but in the end it can be more organized

MVC contains a folder for the Models, Views and Controllers.
Razor Pages contains a folder for the Models, and a folder for the area of the website such as Account and within that folder will be it's Index.cshtml and any other pages related to Account.

A Razor Page is made up by a .cshtml which is the page/view and a .cshtml.cs with is the page model/controller.

You will need to see it because it's hard to explain without showing you.

## Models and DbContext

In order to create a new table in the database you must create a Model which "models" that table and a DbSet for that model in DbContext.

### Creating a Model

Create a new class in the Models folder and give it a name. This will be the name of the table.

Inside the class you define each of the fields including any primary keys or foreign keys.

Here is an example (unfinished):

```cs
 public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string PrimaryAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
```

To let each User have an address you would need to go into the Data/ApplicationUser class and add an AddressId as well as the Address model.

Example with the users address being optional (because of the `?` next to `Guid`):

```cs
    public class ApplicationUser : IdentityUser
    {
        public Guid? AddressId { get; set; }

        public Address Address { get; set; }
    }
```

### Adding the Model to the DbContext

In order to get a list of all addresses you must include them in the DbContext. Ours is called ApplicationDbContext and it is in the Data folder.

To include the list of addresses you will create a DbSet of the Model. You can also rename the table to singular names as shown in this example:

```cs
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
	}
	
    // DbSets for each model
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Rename the new address table to make it singular (personal preference)
        builder.Entity<Address>().ToTable("Address");
    }
}
```

## Mirations

Migrations are what converts your Models and DbSets into code that has the ability to create the database.
When you create a migration it will look for any Models and DbSets inlcuding any changes to them.
This allows us to easily add to the database.

### Adding migrations

In order to add a migration you must type this command in the nuget console

`<migration-name>` could be AddedGameModel

```
add-migration <migration-name>
```

### Creating/updating the database from the migrations

To create or update the database you must use

```
update-database
```

This command will call the `.Up();` method from all of the migrations. 
The migrations will then create the database and the tables. It will also update if the database as already been made and if there's no conflicts.

### Removing migrations.

If you want to remove the migrations to rename them or just revert any changes you must delete the database from the SQL object window and then type:

```
remove-migration
```

If you're unable to remove it with that command you can manually delete the migration.

# Extra Help

There will definitely be questions as this doesn't explain nearly enough. It will explain Git well but not the project itself. 

Please ask for help when needed.
