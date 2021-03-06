        public void Test()
        {
            var resultMap = new ResultMap();
            resultMap.Add(new[] {0}, "a0");
            resultMap.Add(new[] {1, 0}, "b0");
            resultMap.Add(new[] {1, 1, 0}, "c0");
            resultMap.Add(new[] {1, 1, 1}, "c1");
            resultMap.Add(new[] {1, 2}, "b2");
            resultMap.Add(new[] {2}, "a2");
            Debug.Assert("a0" == resultMap.TryGetValue(0));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 0));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 1));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 2));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 0, 0));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 0, 1));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 0, 2));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 1, 0));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 1, 1));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 1, 2));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 2, 0));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 2, 1));
            Debug.Assert("a0" == resultMap.TryGetValue(0, 2, 2));
            Debug.Assert(null == resultMap.TryGetValue(1));
            Debug.Assert("b0" == resultMap.TryGetValue(1, 0));
            Debug.Assert(null == resultMap.TryGetValue(1, 1));
            Debug.Assert("b2" == resultMap.TryGetValue(1, 2));
            Debug.Assert("b0" == resultMap.TryGetValue(1, 0, 0));
            Debug.Assert("b0" == resultMap.TryGetValue(1, 0, 1));
            Debug.Assert("b0" == resultMap.TryGetValue(1, 0, 2));
            Debug.Assert("c0" == resultMap.TryGetValue(1, 1, 0));
            Debug.Assert("c1" == resultMap.TryGetValue(1, 1, 1));
            Debug.Assert(null == resultMap.TryGetValue(1, 1, 2));
            Debug.Assert("b2" == resultMap.TryGetValue(1, 2, 0));
            Debug.Assert("b2" == resultMap.TryGetValue(1, 2, 1));
            Debug.Assert("b2" == resultMap.TryGetValue(1, 2, 2));
            Debug.Assert("a2" == resultMap.TryGetValue(2));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 0));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 1));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 2));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 0, 0));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 0, 1));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 0, 2));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 1, 0));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 1, 1));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 1, 2));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 2, 0));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 2, 1));
            Debug.Assert("a2" == resultMap.TryGetValue(2, 2, 2));
        }
