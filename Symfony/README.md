# Create Project
composer create-project symfony/framework-standard-edition NomProjet Version

Example : `composer.phar create-project symfony/framework-standard-edition SymfonyBlog "3.4.*"`

# Start server
`bin/console server:start`

# Install Fixtures
composer require --dev doctrine/doctrine-fixtures-bundle

Dans AppKernel.php ajouter : `$bundles[] = new Doctrine\Bundle\FixturesBundle\DoctrineFixturesBundle();`

# Generate entity
bin/console doctrine:generate:entity ...

Example : `bin/console doctrine:generate:entity AppBundle:Article --fields="titre:string(100) description:text parution:date actif:boolean"`

# Create Database with Entities
bin/console doctrine:schema:create

Update Database with Entities :	`bin/console doctrine:schema:update --force`

# Load Fixtures in Database
`bin/console doctrine:fixtures:load`
