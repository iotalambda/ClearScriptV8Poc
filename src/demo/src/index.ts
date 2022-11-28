export const run = (): number => {
  console.log('Enter run');
  let value = 5;
  console.log('Break');
  debugger;
  value += 2;
  console.log('Exit run');
  return value;
};