    class KeywordRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            if (token.CSharpKind() == SyntaxKind.ForKeyword)
            {
                return SyntaxFactory.Token(
                    token.LeadingTrivia, SyntaxKind.ForKeyword, "foobar", "foobar",
                    token.TrailingTrivia);
            }
            return token;
        }
    }
