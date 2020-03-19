namespace Domain {
    public sealed class RecommendationScore {
        public RecommendationScore(int score) {
            Score = score;
        }
        
        public int Score { get; }
        
        public static bool operator ==(RecommendationScore right, RecommendationScore left) {
            return object.Equals(right, left);
        }

        public static bool operator !=(RecommendationScore right, RecommendationScore left) {
            return !(right == left);
        }

        public override bool Equals(object obj) {
            if (!(obj is RecommendationScore recommendationScore)) return false;
            if (ReferenceEquals(obj, this)) return true;

            return recommendationScore.Score == this.Score;
        }

        public override int GetHashCode() {
            return this.Score.GetHashCode();
        }
    }
}