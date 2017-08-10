import { CarsPage } from './app.po';

describe('cars App', () => {
  let page: CarsPage;

  beforeEach(() => {
    page = new CarsPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
