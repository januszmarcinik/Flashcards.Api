export interface Card {
  id: string;
  title: string;
  question: string;
  answer: string;
  previousCardId: string;
  nextCardId: string;
}
