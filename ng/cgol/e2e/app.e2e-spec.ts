import { CgolPage } from './app.po';

describe('cgol App', () => {
  let page: CgolPage;

  beforeEach(() => {
    page = new CgolPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
