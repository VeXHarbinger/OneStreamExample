# Development Code Sample


## Intro



## Questions

### Question 1

Given the following

```
class Animal
{
    public virtual string speak(int x) { return "silence"; }
}

class Cat : Animal
{
    public string speak(int x) { return "meow"; }
}

class Dog : Animal
{
    public string speak(short x) { return "bow-wow"; }
}

```

**Question**

Explain why the block below does not emit "bow-wow"

```
Animal  d = new Dog();
Console.Write(d.speak(0));
```

**Answer**

The short answer to the question is that because we are inheriting from our base class Animal so, it can’t access the functionality of the speak command in this instance of the class.  

There are several other issues in this code though. This example “d.speak(0)“ only works because the value 0 could be a short or an int.  So “d.speak(32768)“ would throw an error because the dog's speak signature is a short not int. You cannot use override in dog’s speak function, because the function signatures are different. So while you could strongly type your variable as dog instead of animal or add “new” to the speak function in dog to get the desired response, this is only a partial fix and the functions in dog should be re-written.  


### Question 2

Given the following code;

```
class A
{
     public int a { get; set; }
     public int b { get; set; }
}

class B
{
    public const A a;
    public B(){ a.a = 10; }
}

int main()
{
    B b = new B();
    Console.WriteLine("%d %d\n", b.a.a, b.a.b);
    return 0;
}

```

**Question**

Outline any issues/concerns with the implemented code.


**Answer**

While there is nothing technically wrong with class A, the rest of the code is pretty much non-functional. In class B we declare a constant A which requires a value when declared and can’t be assigned to a new instance of the A class.  As for the final piece of code, aside from just saying it’s wrong, it’s hard to know what it’s supposed to be.  It has the look of a function but isn’t declared inside of a class.  Its name “main” is a bad name for a function as well, for it looks like the entrance to a console application. Within this function there are issues in the Console.WriteLine function appears as if it wants to print two values formatted as an integer, but the items being passed are malformed to say the least. The value of b.a cannot be accessed directly by an instance reference, you need to use a class to qualify it. So to resolve the first expected value, you need to access it this way;

```
B b = new B();
A c = B.a;
int d1 = c.a;
int d2 = c.b;

Console.WriteLine("%d %d\n", d1, d2);
```

## Code Example

### Intro

This is a Blazor application designed to host the predefined API example.  When it is run there are two options available; First, there is a link to see the pulled API data bound to a UI, I didn't go so far though as to implement the round trip calls to use the POST function to update the rendered data.  Secondly, there is a link to a swagger page where you can test the API as well as see schema information relating what the properties are.    


#### Services (3rd Party APIs)

These are the API services I pull data from

* [Useless Facts](https://uselessfacts.jsph.pl)
* [Meow Facts](https://meowfacts.herokuapp.com)

*I wanted to use APIs that didn't require a Auth key.*

#### My APIs

I created a very basic API called "UserDashboardData".  It's get function returns a populated data wrapper of the 2 3rd party API calls.
I then created a POST function where users could change the 2 input values (catFactCount & isRandomFactSelected) and the API returns the wrapper with the newly pulled data within. 


### Definition of Done

* Supports Get & Post verbs
* Needs an API endpoint that can
  * Accept an HTTP GET Request
  * Accept an HTTP POST Request
  *	Returns data sets from 2 different 3rd Party APIs
