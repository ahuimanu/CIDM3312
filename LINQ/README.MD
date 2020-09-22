# LINQ

The Language Integrated Query features of C# are vital if we are to understand and work with Entity Framework, which is our current goal.  Prior to working with the database, let's practice working with records of data on a simple single entity.

## Iris Data and Queries

The [Iris Dataset](https://archive.ics.uci.edu/ml/datasets/Iris) is a classic basic statistics data set that [goes back to 1936](https://en.wikipedia.org/wiki/Iris_flower_data_set).

It creates a simple context from which we can establish some basic LINQ prowess.

### Queries to run

1. Create and show a LINQ Query that lists all Sepal Widths that are above the average Sepal Width
1. Create and show a LINQ Query that lists all Sepal Lengths that are below the average Sepal Length
1. Create and show a LINQ Query that indicates which class of iris has the lowest average Petal Width
1. Create and show a LINQ Query that indicates which class of iris has the highest average Petal Length 
1. Create and show a LINQ Query that indicates the widest Sepal Width for each class of iris
1. Create and show a LINQ Query that indicates the shortest Sepal Length for each class of iris
1. Create and show a LINQ Query that indicates the ranks the top 5 widest Petal Widths
1. Create and show a LINQ Query that indicates the ranks the bottom 5 shortest Petal Lengths
1. Create and show a LINQ Query that indicates the median Sepal Width for each class of iris
1. Create and show a LINQ Query that indicates the mode Petal Length for each class of iris

### C# LINQ Aggregation Methods

There are [several methods](https://www.csharp-examples.net/linq-aggregation-methods/) available to perform the aggregations neccessary to develop the queries needed in the list above.

