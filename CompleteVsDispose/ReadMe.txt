This WPF application show two approaches to dispose view models that are listening to an RX observable.

The first approach is the classic way, we are calling Dispose and the parent ViewModel, that with dispose his subscription on the observable and call Dispose on all its children view model that will be doing same.
The second approach is completing the source observable. All of the subscriptions will complete gracefully.

In the second approach, both Parent and children have the same lifetime. In a case when we want to remove a single view model we would have to implement the same logic for the child.

Less code.
More functional programing way of doing, the observable is driving the full screen.
Add coupling between parent and child.

Add a comment as people have a habit to make every class with a subscription to be IDisposable.

This article is a similar problem as the one found there: https://medium.com/@benlesh/rxjs-dont-unsubscribe-6753ed4fda87