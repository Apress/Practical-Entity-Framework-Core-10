# Listing 8-18: Disable Tracking for all queries by default.

If your scenario is read-only heavy or you just want to optimize for no tracking, just update the constructors for your DbContext to ensure that the default behavior is no tracking.

## The code

In the constructor(s) add the following code (or leverage a common method from the constructors)

```cs
ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
````  