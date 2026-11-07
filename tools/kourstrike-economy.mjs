// Exact-build scalar changes. Reuse the original native cash addition, cap,
// HUD callbacks and phase deduplication; only replace reward selection.
export const economyRules=Object.freeze({startingCredits:800,walletCap:14000,win:3000,lossBase:1500,lossStep:500,maxLossStreak:3});
export const economyPatches=Object.freeze([
 {method:'SearchAndDestroyManager.OnStateChanged',offset:23693502,before:'41f80a',after:'410001',meaning:'No unconditional buy-phase income; explicit first-round 800 is preserved'},
 {method:'SearchAndDestroyManager.OnStateChanged',offset:23695642,before:'027f410010efc201410010e7c2042207044041b21920042007280208410010a4c9050d011a0b41981141f80a200028029c01220441f80a461b220520002802a00141f80a470d001a41a81420052004419811461b0b2105',after:'410010efc201410010e7c2042207047f20042007280208410010a4c9050541000b047f200041003602a00141b81705200020002802a00141016a2204410320044103481b22043602a00141dc0b200441f4036c6a0b2105',meaning:'Win 3000/reset streak; loss 1500+500*min(streak+1,3); manager+160 stores the local player streak'},
 {method:'SearchAndDestroyManager.OnStateChanged',offset:23695916,before:'3602a001',after:'1a1a0101',meaning:'Keep the streak counter instead of overwriting it with the awarded credits'}
]);
