namespace Domain {
    // Example of a class used to create value objects
    public sealed class RecommendationScore {
        public RecommendationScore(int score) {
            Score = score;
        }
        
        public int Score { get; } // No setter
        
        // Methods to check for equality
        public static bool operator ==(
            RecommendationScore right,
            RecommendationScore left) => object.Equals(right, left);

        public static bool operator !=(
            RecommendationScore right,
            RecommendationScore left) => !(right == left);

        public override bool Equals(object obj) {
            if (!(obj is RecommendationScore recommendationScore)) return false;
            if (ReferenceEquals(obj, this)) return true;

            return recommendationScore.Score == this.Score;
        }

        public override int GetHashCode() => this.Score.GetHashCode();
    }
}