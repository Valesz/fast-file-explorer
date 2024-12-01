using BWE8LT.Controller;

namespace BWE8LT.Model;

public abstract record Command<TKey>(
    TKey Key,
    Action<TKey, IConsoleController> Action
);