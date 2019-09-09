using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library
{
    public class MatchResultListener : IMatchResultListener
    {
        private Stack<StringBuilder> _messages;

        public class Scope : IScope
        {
            private readonly MatchResultListener _listener;
            private readonly int _height;
            private readonly StringBuilder _builder;

            public Scope(MatchResultListener listener)
            {
                _listener = listener;
                _height = _listener.Count();
                _builder = _listener.Peek();
            }

            public void DropScope()
            {
                _listener.DropScope(_height);
            }

            public void Dispose()
            {
                _listener.MergeScope(_height);
            }

            public StringBuilder Append(string message)
            {
                _builder.Append(' ', _height).Append(message);
                return _builder;
            }

            public StringBuilder AppendLine(string message)
            {
                _builder.Append(' ', _height).AppendLine(message);
                return _builder;
            }
        }

        public MatchResultListener()
        {
            _messages = new Stack<StringBuilder>();
            _messages.Push(new StringBuilder());
        }

        public string Message()
        {
            var streamPrev = _messages.Pop();
            if (streamPrev == null) return string.Empty;

            while (_messages.Count > 0)
            {
                var streamCur = _messages.Pop();
                streamCur.Append(streamPrev);
                streamPrev = streamCur;
            }

            return streamPrev.ToString();
        }

        public IScope NewScope()
        {
            _messages.Push(new StringBuilder());
            return new Scope(this);
        }

        public StringBuilder Append(string message)
        {
            var builder = _messages.Peek();
            builder.Append(' ', _messages.Count).Append(message);
            return builder;
        }

        public StringBuilder AppendLine(string message)
        {
            var builder = _messages.Peek();
            builder.Append(' ', _messages.Count).AppendLine(message);
            return builder;
        }

        private void MergeScope(int height)
        {
            while (_messages.Count >= height)
            {
                var builder = _messages.Pop();
                _messages.Peek().Append(builder);
            }
        }

        private void DropScope(int height)
        {
            while (_messages.Count >= height)
            {
                _messages.Pop();
            }
        }

        private int Count()
        {
            return _messages.Count;
        }

        private StringBuilder Peek()
        {
            return _messages.Peek();
        }
    }
}
