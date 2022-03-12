function execute(score)
	userDiff = user.MaxHP - user.CurrentHP
	for i, v in ipairs(targets) do
		enemyDiff = v.MaxHP - user.CurrentHP
		
		user.Damage(userDiff + enemyDiff)
		v.Damage(userDiff + enemyDiff)
	end
end