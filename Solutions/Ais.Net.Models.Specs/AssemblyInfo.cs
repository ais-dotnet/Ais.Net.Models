using Microsoft.VisualStudio.TestTools.UnitTesting;

// MSTest 4.0 requires explicit parallelization configuration (MSTEST0001).
// Workers = 0 uses all available cores; MethodLevel allows tests to run concurrently.
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
